public class Player {

    public short TotalSessions { get; set; }
    public bool IsNew { get; set; }
    public string SaveDate { get; set; }

    public void IncrementSessionsCounter() {
        TotalSessions++;
    }
}
