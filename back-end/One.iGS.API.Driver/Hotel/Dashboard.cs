using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.iGS.API.Driver.Hotel
{
    public static class Dashboard
    {
        public static List<Models.Hotel.Dashboard.PendingReservation> PendingReservation()
        {
            using (ParadiseDataContext context = new ParadiseDataContext())
            {
                try
                {
                    var a = from reservation in context.RESERVA
                            join room in context.HABITACION on reservation.ResHab equals room.HabNum
                            join holder in context.PASAJEROS on reservation.ResPaxTit equals holder.PaxCod
                            where reservation.ResEsta == "RESINDIV" && reservation.ResConfirm != 'S' && reservation.ResFecEnt >= DateTime.UtcNow.Date
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
                catch (Exception ex) {
                    throw new Exception("Error al obtener los datos de reservas pendientes", ex);
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
    }

}
