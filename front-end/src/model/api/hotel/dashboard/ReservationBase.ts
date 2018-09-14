export class ReservationBase {
    public Id: string | undefined
    public RoomId: string | number | undefined
    public RoomNumber: number | undefined
    public RoomName: string | undefined
    public CheckIn: Date | undefined
    public CheckOut: Date | undefined
    public HolderId: string | number | undefined
    public HolderName: string | undefined
    public HolderSurname: string | undefined
    public Adults: number = 0
    public Childrens: number = 0
    public Babies: number = 0
}

export default ReservationBase