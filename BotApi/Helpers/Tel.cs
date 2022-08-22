using BotApi.Models.WebHotelier;
using BotApi.Services.WebHotelier;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApi.Helpers
{
    public static class Tel
    {
        public static InlineKeyboardMarkup GetInlineKeybord(List<string> inlineItems, int columns = 3)
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();

            int index = 0;
            foreach (var item in inlineItems)
            {
                index++;
                cols.Add(InlineKeyboardButton.WithCallbackData(item, item));

                if (columns > 1 || inlineItems.Count > 1)
                {
                    if (index % columns != 0)
                        continue;
                }

                rows.Add(cols.ToArray());
                cols = new List<InlineKeyboardButton>();
            }

            return new InlineKeyboardMarkup(rows.ToArray());
        }

        public static InlineKeyboardMarkup GetInlineKeyboard(PropertyModel propertyModel, int columns = 3)
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();

            int index = 0;
            foreach (var h in propertyModel.Data.Hotels.Take(27))
            {
                index++;
                cols.Add(InlineKeyboardButton.WithCallbackData($"{h.Name}", $"{C.HotelPick}{h.Name}:{h.Code}"));

                if (columns > 1 || propertyModel.Data.Hotels.Count > 1)
                {
                    if (index % columns != 0)
                        continue;
                }

                rows.Add(cols.ToArray());
                cols = new List<InlineKeyboardButton>();
            }

            return new InlineKeyboardMarkup(rows.ToArray());
        }

        public static InlineKeyboardMarkup GetInlineKeyboardPax(List<RoomListingModelRoom> paxCombinations, int columns = 3, string callbackMessage = "")
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();

            int index = 0;
            foreach (var p in paxCombinations)
            {
                index++;
                if (callbackMessage != "")
                {
                    cols.Add(InlineKeyboardButton.WithCallbackData(p.Name, $"{callbackMessage}{p.Name}"));
                }
                else
                {
                    cols.Add(InlineKeyboardButton.WithCallbackData(p.Name, p.Name));
                }

                if (columns > 1)
                {
                    if (index % columns != 0)
                        continue;
                }

                rows.Add(cols.ToArray());
                cols = new List<InlineKeyboardButton>();
            }

            return new InlineKeyboardMarkup(rows.ToArray());
        }

        public static InlineKeyboardMarkup GetInlineKeybordByDictionary(Dictionary<string, string> inlineItems, int columns = 3)
        {
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();

            int index = 0;
            foreach (var item in inlineItems)
            {
                index++;
                cols.Add(InlineKeyboardButton.WithCallbackData(item.Key, item.Value));

                if (columns > 1 || inlineItems.Count > 1)
                {
                    if (index % columns != 0)
                        continue;
                }

                rows.Add(cols.ToArray());
                cols = new List<InlineKeyboardButton>();
            }

            return new InlineKeyboardMarkup(rows.ToArray());
        }

        public static string TakeTextAfter(string text, string takeAfter)
        {
            return text.Substring(text.IndexOf(takeAfter) + takeAfter.Length);
        }

        public static string TakeTextBefore(string text, string takeBefore)
        {
            return text.Substring(0, text.IndexOf(takeBefore));
        }

        public static string ExtractTextFromRegexByGroup(string text, string pattern, int group, RegexOptions options = RegexOptions.IgnoreCase)
        {
            var match = Regex.Match(text, pattern, options).Groups[group].Value;
            var result = Regex.Replace(match, @"\s+", " ");

            return result.Trim();
        }

        public static string GetTextFromHtml(string html)
        {
            HtmlDocument htmlDoc = new();

            htmlDoc.LoadHtml(html);
            string description = string.Empty;
            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//text()"))
            {
                description += node.InnerText;
            }

            var descriptionDecoded = WebUtility.HtmlDecode(description);
            return descriptionDecoded;
        }
    }
}
