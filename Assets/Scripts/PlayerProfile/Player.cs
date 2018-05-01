public class Player {

    public short TotalSessions { get; set; }
    public bool IsNew { get; set; }

    public void IncrementSessionsCounter() {
        TotalSessions++;
    }
}
