//this class is used for created Game Settings for them to be further stored in the Main Menu Class
public class GameSettings {
    //The Master Volume Of The Game
    public float volume;
    //The Quality Of The Game Graphics
    public int quality;
    //A Bool That Is Whether Or Not The Game Is Played In Fullscreen
    public bool fullScreen;
    //Current Date On The Players Computer, This Will Determine Seasonal Changes To The Map
    public int month;

    public GameSettings(float volume, int quality, bool fullScreen, int month) {
        this.volume = volume;
        this.quality = quality;
        this.fullScreen = fullScreen;
        this.month = month;
    }
}
