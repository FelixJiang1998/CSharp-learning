namespace FilterDemo.API.Models;

public class Actions
{
    public int Id { get; set; }
    public string ActionName { get; set; }
    public string ControllerName { get; set; }


    public static List<Actions> GetActionByUserId(int userId)
    {
        if (userId == 6)
        {
            return new List<Actions>
            {
                new Actions { Id = 1, ActionName = "Get", ControllerName = "WeatherForecast" }
            };
        }

        return default;
    }
}