public class WeatherStation {
    public static void main(String[] args) {
        WeatherData weatherData = new WeatherData();
        CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData);
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
        ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
        HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);

     
        weatherData.setMeasurements(80f, 65f, 30.4f);       
        weatherData.setMeasurements(81f, 66f, 98.7f);
        weatherData.setMeasurements(82f, 67f, 99.4f); 
                
    }
}
