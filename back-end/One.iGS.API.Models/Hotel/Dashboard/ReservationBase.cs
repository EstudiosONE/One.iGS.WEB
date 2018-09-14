using System;

namespace One.iGS.API.Models.Hotel.Dashboard
{
    public class ReservationBase
    {
        public string Id { get; set; }
        public short RoomNumber { get; set; }
        public string RoomName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string HolderId { get; set; }
        public string HolderName { get; set; }
        public string HolderSurname { get; set; }
        public short Adults { get; set; }
        public short Childrens { get; set; }
        public short Babies { get; set; }
    }
}
