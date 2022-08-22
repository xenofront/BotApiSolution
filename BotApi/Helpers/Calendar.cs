using System;
using System.Collections.Generic;
using System.Globalization;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApi.Helpers
{
    public static class Calendar
    {
        private readonly static DateTimeFormatInfo _dtInfo = new CultureInfo("ru-RU").DateTimeFormat;

        public static InlineKeyboardMarkup GetCalendar(in DateTime date, string dateFromOrDateUntil = C.PickDateGeneric)
        {
            var keyboardRows = new List<IEnumerable<InlineKeyboardButton>>();

            keyboardRows.Add(RowDate(date, _dtInfo));
            keyboardRows.Add(RowControls(date));
            keyboardRows.AddRange(RowMonths(date, _dtInfo));
            keyboardRows.Add(RowDayOfWeek(_dtInfo));
            keyboardRows.AddRange(DayRows(date, _dtInfo, dateFromOrDateUntil));

            return new InlineKeyboardMarkup(keyboardRows);
        }

        private static IEnumerable<InlineKeyboardButton> RowDate(in DateTime date, DateTimeFormatInfo dtInfo)
        {
            return new InlineKeyboardButton[] { Cell($"{date.ToString("Y", dtInfo)}", $"{C.NoCommandCell}") };
        }

        private static IEnumerable<IEnumerable<InlineKeyboardButton>> RowMonths(DateTime date, DateTimeFormatInfo dtInfo)
        {
            for (int month = 0, months = 0; months < 3; months++)
            {
                yield return NewRowOfMonths(ref month);
            }

            IEnumerable<InlineKeyboardButton> NewRowOfMonths(ref int month)
            {
                var months = new InlineKeyboardButton[4];

                for (int i = 0; i < 4; i++)
                {
                    var cellMonth = new DateTime(date.Year, month + 1, 1);
                    var currentMonth = DateTime.Now;

                    if (currentMonth > cellMonth)
                    {
                        months[i] = EmptyCell();
                    }
                    else
                    {
                        months[i] = Cell(dtInfo.AbbreviatedMonthNames[month], $"{C.ChangeMonth}{cellMonth.ToString(C.DateFormat)}");
                    }
                    month++;
                }

                return months;
            }
        }

        private static IEnumerable<InlineKeyboardButton> RowDayOfWeek(DateTimeFormatInfo dtInfo)
        {
            var firstDayOfWeek = (int)dtInfo.FirstDayOfWeek;
            for (int i = 0; i < 7; i++)
            {
                yield return Cell(dtInfo.AbbreviatedDayNames[(firstDayOfWeek + i) % 7], $"{C.NoCommandCell}");
            }
        }

        private static IEnumerable<IEnumerable<InlineKeyboardButton>> DayRows(DateTime date, DateTimeFormatInfo dtInfo, string dateFromOrDateUntil = "")
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1).Day;

            for (int dayOfMonth = 1, weekNum = 0; dayOfMonth <= lastDayOfMonth; weekNum++)
            {
                yield return NewWeek(weekNum, ref dayOfMonth);
            }

            IEnumerable<InlineKeyboardButton> NewWeek(int weekNum, ref int dayOfMonth)
            {
                var week = new InlineKeyboardButton[7];
                var currDate = DateTime.Now;

                for (int dayOfWeek = 0; dayOfWeek < 7; dayOfWeek++)
                {
                    if ((weekNum == 0 && dayOfWeek < FirstDayOfWeek()) || dayOfMonth > lastDayOfMonth)
                    {
                        week[dayOfWeek] = EmptyCell();
                        continue;
                    }

                    var currDay = new DateTime(date.Year, date.Month, dayOfMonth);
                    if (currDate.Date > currDay)
                    {
                        week[dayOfWeek] = EmptyCell();
                    }
                    else
                    {
                        week[dayOfWeek] = Cell(dayOfMonth.ToString(), $"{dateFromOrDateUntil}{currDay.ToString(C.DateFormat)}");
                    }

                    dayOfMonth++;
                }
                return week;

                int FirstDayOfWeek() => (7 + (int)firstDayOfMonth.DayOfWeek - (int)dtInfo.FirstDayOfWeek) % 7;
            }
        }

        private static IEnumerable<InlineKeyboardButton> RowControls(in DateTime date)
        {
            var currentYear = DateTime.Now.Year;

            if (currentYear < date.Year)
            {
                return new InlineKeyboardButton[]
                    {
                        Cell($"{date.Year -1} <<", $"{C.PreviousYear}{date.ToString(C.DateFormat)}"),
                        Cell($">> {date.Year + 1}", $"{C.NextYear}{date.ToString(C.DateFormat)}")
                    };
            }
            else
            {
                return new InlineKeyboardButton[] { Cell($">> {date.Year + 1}", $"{C.NextYear}{date.ToString(C.DateFormat)}") };
            }

        }
        private static InlineKeyboardButton EmptyCell()
        {
            return Cell(" ", $"{C.NoCommandCell}");
        }
        private static InlineKeyboardButton Cell(string text, string callbackData)
        {
            return InlineKeyboardButton.WithCallbackData(text, callbackData);
        }
    }
}