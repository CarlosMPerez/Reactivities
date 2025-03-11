import { DateArg, format } from "date-fns";

const utils = {
    formatDate: (date: DateArg<Date>) => format(date, "dd MMM yyyy HH:mm")
}

export default utils;

