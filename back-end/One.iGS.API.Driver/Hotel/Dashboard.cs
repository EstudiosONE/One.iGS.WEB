using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace One.iGS.API.Driver.Hotel
{
    public static class Dashboard
    {
        #region Check In

        public static List<Models.Hotel.Dashboard.CheckInToday> CheckInToday()
        {
            using (ParadiseDataContext context = new ParadiseDataContext())
            {
                try
                {
                    var a = from reservation in context.RESERVA
                            join room in context.HABITACION on reservation.ResHab equals room.HabNum
                            join holder in context.PASAJEROS on reservation.ResPaxTit equals holder.PaxCod
                            where reservation.ResEsta != "CANCEL." && reservation.ResFecEnt == DateTime.Now.Date
                            orderby reservation.ResEsta descending, reservation.ResHab.Value
                            select new Models.Hotel.Dashboard.CheckInToday()
                            {
                                Id = reservation.ResNro.ToString(),
                                CheckIn = reservation.ResFecEnt.Value,
                                CheckOut = reservation.ResFecSal.Value,
                                Adults = reservation.ResCamMat.Value,
                                Childrens = reservation.ResCamSin.Value,
                                Babies = reservation.ResCamCun.Value,
                                RoomNumber = room.HabNum,
                                RoomName = room.HabNom.TrimEnd(' '),
                                HolderId = holder.PaxCod.ToString(),
                                HolderName = holder.PaxNom.TrimEnd(' '),
                                HolderSurname = holder.PaxApe.TrimEnd(' '),
                                Ocupation = IsOccupied(reservation.ResEsta),
                                Confirmation = IsConfirmed(reservation.ResConfirm),
                                EntryTime = EntryTime(reservation.ResFecEnt, reservation.ResFecEntHor)
                            };
                    return a.ToList();
                }
                catch (Exception ex)
                {
                    Log.Helper.Notify(ex);
                    throw new HttpException(500, ex.Message);
                }
            }
        }

        private static bool IsOccupied(string value)
        {
            if (value.TrimEnd(' ') == "OCUPADA") return true;
            else return false;
        }

        private static bool IsConfirmed(char? value)
        {
            if (value.HasValue)
                if (value.Value == 'S') return true;
                else return false;
            else return false;
        }

        private static DateTime EntryTime(DateTime? CheckIn, string Hour)
        {
            return CalculatedTime(CheckIn, Hour);
        }

        #endregion

        #region Check Out

        public static List<Models.Hotel.Dashboard.CheckOutToday> CheckOutToday()
        {
            using (ParadiseDataContext context = new ParadiseDataContext())
            {
                try
                {
                    var a = from reservation in context.RESERVA
                            join room in context.HABITACION on reservation.ResHab equals room.HabNum
                            join holder in context.PASAJEROS on reservation.ResPaxTit equals holder.PaxCod
                            where reservation.ResEsta != "CANCEL." && reservation.ResFecSal == DateTime.Now.Date
                            orderby reservation.ResHab.Value
                            select new Models.Hotel.Dashboard.CheckOutToday()
                            {
                                Id = reservation.ResNro.ToString(),
                                CheckIn = reservation.ResFecEnt.Value,
                                CheckOut = reservation.ResFecSal.Value,
                                Adults = reservation.ResCamMat.Value,
                                Childrens = reservation.ResCamSin.Value,
                                Babies = reservation.ResCamCun.Value,
                                RoomNumber = room.HabNum,
                                RoomName = room.HabNom.TrimEnd(' '),
                                HolderId = holder.PaxCod.ToString(),
                                HolderName = holder.PaxNom.TrimEnd(' '),
                                HolderSurname = holder.PaxApe.TrimEnd(' '),
                                Released = IsReleased(reservation.ResEsta),
                                ReleaseTime = ReleaseTime(reservation.ResFecSal, reservation.ResLateCheckOut)
                            };
                    return a.ToList();
                }
                catch (Exception ex)
                {
                    Log.Helper.Notify(ex);
                    throw new HttpException(500, ex.Message);
                }
            }
        }

        private static DateTime ReleaseTime(DateTime? CheckOut, char? LateCheckOut)
        {
            const string NormalCheckOut_Hour = "11:00";
            const string LateCheckOut_Hour = "20:00";

            return CalculatedTime(CheckOut, LateCheckOut.Value == 'S' ? LateCheckOut_Hour : NormalCheckOut_Hour);
        }

        private static bool IsReleased(string value)
        {
            if (value.TrimEnd(' ') == "LIBRE") return true;
            else return false;
        }

        #endregion

        #region Pending Reservaion

        public static List<Models.Hotel.Dashboard.PendingReservation> PendingReservation()
        {
            using (ParadiseDataContext context = new ParadiseDataContext())
            {
                try
                {
                    var a = from reservation in context.RESERVA
                            join room in context.HABITACION on reservation.ResHab equals room.HabNum
                            join holder in context.PASAJEROS on reservation.ResPaxTit equals holder.PaxCod
                            where reservation.ResEsta == "RESINDIV" && reservation.ResConfirm != 'S' && reservation.ResFecEnt >= DateTime.Now.Date
                            orderby reservation.ResFecEnt, reservation.ResHab.Value
                            select new Models.Hotel.Dashboard.PendingReservation()
                            {
                                Id = reservation.ResNro.ToString(),
                                CheckIn = reservation.ResFecEnt.Value,
                                CheckOut = reservation.ResFecSal.Value,
                                Adults = reservation.ResCamMat.Value,
                                Childrens = reservation.ResCamSin.Value,
                                Babies = reservation.ResCamCun.Value,
                                RoomNumber = room.HabNum,
                                RoomName = room.HabNom.TrimEnd(' '),
                                HolderId = holder.PaxCod.ToString(),
                                HolderName = holder.PaxNom.TrimEnd(' '),
                                HolderSurname = holder.PaxApe.TrimEnd(' '),
                                Risk = CalculateRisk(reservation.ResFecIng.Value, reservation.ResFecEnt.Value, reservation.ResFecSal.Value, reservation.ResNro)
                            };
                    return a.ToList();
                }
                catch (Exception ex)
                {
                    Log.Helper.Notify(ex);
                    throw new HttpException(500, ex.Message);
                }
            }
        }

        private static short CalculateRisk(DateTime Creation, DateTime CheckIn, DateTime CheckOut, int resnro)
        {
            var stay = (CheckOut - CheckIn).TotalDays;
            var timeFromCreationToCheckIn = (CheckIn - Creation).TotalDays;
            var timeFromTodayToCheckIn = (CheckIn - DateTime.Now.Date).TotalDays;

            var factor = 100 / timeFromCreationToCheckIn;
            var stayFactor = stay * 1.5;

            var Risk = (factor * (timeFromCreationToCheckIn - timeFromTodayToCheckIn)) + stayFactor;

            switch (Risk)
            {
                case Double n when (n < 20): return 1;
                case Double n when (n < 40): return 2;
                case Double n when (n < 60): return 3;
                case Double n when (n < 80): return 4;
                case Double n when (n >= 80): return 5;
                default: return 5;
            }
        }

        #endregion

        #region Common

        private static DateTime CalculatedTime(DateTime? Date, string Time)
        {
            try
            {
                return Date.Value.Add(TimeSpan.Parse(Time));
            }
            catch(Exception)
            {
                return Date.Value;
            }
        }

        #endregion
    }
}
