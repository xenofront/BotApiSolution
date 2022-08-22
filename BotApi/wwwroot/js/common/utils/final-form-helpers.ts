import { addDays, compareAsc } from "date-fns";
import { MutableState, Tools } from "final-form";

export default function changeDates(
  args: any,
  state: MutableState<any, Partial<any>>,
  utils: Tools<any, Partial<any>>
) {
  // args: 0- datefrom, 1-dateTo, 2-type(1 is from), 3-fieldName
  const dateFrom = args[0];
  const dateTo = args[1];
  if (dateFrom && dateFrom != null && dateTo && dateTo != null) {
    if (compareAsc(dateTo, dateFrom) < 1) {
      if (args[2] == 1) {
        utils.changeValue(state, args[3], () => addDays(dateFrom, 1));
      } else {
        utils.changeValue(state, args[3], () => addDays(dateTo, -1));
      }
    }
  }
}
