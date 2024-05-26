using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace cs2_server_status;

public class Config : BasePluginConfig {

    [JsonPropertyName("DcWebhook")] public string DcWebHook {get; set;} = "";
    [JsonPropertyName("WebHookName")] public string WebHookName {get;set;} = "Utopia V2";
    [JsonPropertyName("MapImages")] public Dictionary<string, string> MapImages {get; set;} = new Dictionary<string, string>{
        {"cs_italy","https://developer.valvesoftware.com/w/images/5/5d/Cs_italy.png"},
        {"cs_office", "https://developer.valvesoftware.com/w/images/9/96/Cs_office.png"},
        {"ar_shoots", "https://developer.valvesoftware.com/w/images/5/5d/Ar_shoots.png"},
        {"ar_baggage","https://developer.valvesoftware.com/w/images/c/c4/Ar_baggage.png"},
        {"de_ancient","https://developer.valvesoftware.com/w/images/9/94/De_ancient.png"},
        {"de_anubis", "https://developer.valvesoftware.com/w/images/5/54/De_anubis.png"},
        {"de_dust2","https://developer.valvesoftware.com/w/images/f/f4/De_dust2.png"},
        {"de_inferno","https://developer.valvesoftware.com/w/images/b/be/De_inferno.png"},
        {"de_mirage","https://developer.valvesoftware.com/w/images/6/68/De_mirage.png"},
        {"de_nuke","https://developer.valvesoftware.com/w/images/5/57/De_nuke.png"},
        {"de_overpass","https://developer.valvesoftware.com/w/images/d/dc/De_overpass.png"},
        {"de_vertigo","https://developer.valvesoftware.com/w/images/d/d5/De_vertigo.png"},
        {"lobby_mapveto","https://developer.valvesoftware.com/w/images/c/c5/Lobby_mapveto.png"},
    };
    [JsonPropertyName("Embeds")] public Dictionary<string, Embed> Embeds {get; set;} = new Dictionary<string, Embed>{
        {"map_change", new Embed{
            title = "Map Change",
            color = 0x58b9ff,
            description = "Map have changed!",
            image = new EmbedImage{
                url = "map_image"
            },
            thumbnail = new EmbedImage{
                url = "thumbnail"
            },
            footer = new EmbedFooter{
                text = "connect utopiav2.hu",
                icon_url = "footer_icon",
            },
            fields = [
                new EmbedField{
                    name = "Map",
                    value = "{0}",
                    inline = true
                }
            ],
        }}
    };
}

public class DcEmbed {
    public string username {get; set;} = "afgán";
    public Embed[] embeds = [];
}

public class Embed {
    public string type = "rich";
    public string title {get; set;} = "";
    public string description {get; set;} = "";
    public int color {get; set;} = 0;
    public EmbedFooter footer {get; set;} = new EmbedFooter{};
    public EmbedImage image {get; set;} = new EmbedImage{};
    public EmbedImage thumbnail {get; set;} = new EmbedImage{};
    public EmbedField[] fields {get; set;} = [];
}

public class EmbedImage{
    public string url {get;set;} = "";
}

public class EmbedFooter {
    public string text {get; set;} = "";
    public string icon_url {get; set;} = "";
}

public class EmbedField{
    public string name {get; set;} = "";
    public string value {get; set;} = "";
    public bool inline {get; set;} = false;
}