namespace AppAPI.Models;

public class Reservation
{
    public int ReservationId { get; set; }
    public long SeatNumber { get; set; }
    public long UserId { get; set; }
    public long ProjectionId { get; set; }

    public Reservation(long seatNumber, long userId, long projectionId)
    {
        SeatNumber = seatNumber;
        UserId = userId;
        ProjectionId = projectionId;
    }
}