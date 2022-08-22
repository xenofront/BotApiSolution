import { format as formatDate } from "date-fns";

export function postDateField(date: any, format: string = "yyyy-MM-dd") {
  return date ? formatDate(date, format) : null;
}
