namespace AppAPI.Models;

public class Reservation
{
    public int ReservationId { get; set; }
    public int SeatNumber { get; set; }
    public int UserId { get; set; }
    public int ProjectionId { get; set; }

    public Reservation(int seatNumber, int userId, int projectionId)
    {
        SeatNumber = seatNumber;
        UserId = userId;
        ProjectionId = projectionId;
    }
}