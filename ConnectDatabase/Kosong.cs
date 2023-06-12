public void DownloadXML()
{
    WebClient webClient = new WebClient();
    Uri url = new Uri("https://data.bmkg.go.id/DataMKG/MEWS/DigitalForecast/DigitalForecast-JawaTimur.xml");

    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
    webClient.DownloadFileAsync(url, xmlInputDir + "/DigitalForecast-JawaTimur.xml");
}