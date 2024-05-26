using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;
using System.Text;

namespace cs2_server_status;
public class Cs2ServerStatus : BasePlugin, IPluginConfig<Config> {
    public override string ModuleName => "Server Status over Discord webhook";
    public override string ModuleAuthor => "OwnSample";
    public override string ModuleDescription => "Send stauts updated to a discord webhook in embed form";
    public override string ModuleVersion => "0.0.1";
    public Config Config { get; set; } = new Config{};

    public void OnConfigParsed(Config config) {
        if (config.DcWebHook == string.Empty){
            throw new Exception("No dc webhook url");
        }
        Config = config;
    }
    public override void Load(bool hotReload) {
        RegisterListener<Listeners.OnMapStart>(map => {
            var OgSection = Config.Embeds["map_change"];
            Config.Embeds["map_change"].fields[0].value = string.Format(Config.Embeds["map_change"].fields[0].value, map);
            Config.Embeds["map_change"].fields[1].value = string.Format(Config.Embeds["map_change"].fields[1].value, Utilities.GetPlayers().Count ,Server.MaxPlayers);
            Config.Embeds["map_change"].image = new EmbedImage{ url = Config.MapImages[map]};
            var embed = new DcEmbed{
                username = Config.WebHookName,
                embeds = [
                    Config.Embeds["map_change"]
                ]
            };
            _ = SendWebhookMessage(Newtonsoft.Json.JsonConvert.SerializeObject(embed));
            Config.Embeds["map_change"] = OgSection;
        });
        Console.WriteLine("Hello World!");
    }
    public async Task SendWebhookMessage(string Message) {
		using (var httpClient = new HttpClient()) {
			var content = new StringContent(Message, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync(Config.DcWebHook, content);
			if (!response.IsSuccessStatusCode) {
				Logger.LogCritical($"Failed to send message to Discord webhook. Status code: {response.StatusCode}");
			}
        }
	}
}
