import { goto } from "$app/navigation";

export function load({ url }) {
    const queryParams = new URLSearchParams(url.search);

    const targetDate = new Date();
    const year = targetDate.getFullYear().toString();
    targetDate.setDate(targetDate.getDate() + 4 - (targetDate.getDay() || 7));
    const firstThursday = new Date(targetDate.getFullYear(), 0, 4);
    const week = Math.ceil(((targetDate.getTime() - firstThursday.getTime()) / (1000 * 60 * 60 * 24) + firstThursday.getDay() - 1) / 7);

    return {
        week: parseInt(queryParams.get("week") || week.toString(), 10),
        year: parseInt(queryParams.get("year") || year, 10),
    };
}