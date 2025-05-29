export async function fetchSchedule(startDate: Date, endDate: Date): Promise<{ data: string | null; error: string | null }> {
    try {
        const response = await fetch('http://localhost:5133/schedule/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                startDate,
                endDate
            })
        });
        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
        const data = await response.json();
        return { data, error: null };
    } catch (err: any) {
        return { data: null, error: err.message };
    }
}

export async function fetchScheduleQuery(year: number, week: number): Promise<{ data: string | null; error: string | null }> {
    try {
        const url = new URL("http://localhost:5133/schedule");
        url.searchParams.set("year", year.toString());
        url.searchParams.set("week", week.toString());

        const response = await fetch(url, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        });
        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
        const data = await response.json();
        return { data, error: null };
    } catch (err: any) {
        return { data: null, error: err.message };
    }
}