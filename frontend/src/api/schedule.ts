export async function fetchSchedule(startDate: Date, endDate: Date): Promise<{ data: string | null; error: string | null }> {
    try {
        const response = await fetch('http://localhost:5133/schedule/', {
            method: 'GET',
            body: JSON.stringify({ startDate, endDate })
        });
        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
        const data = await response.json();
        return { data, error: null };
    } catch (err: any) {
        return { data: null, error: err.message };
    }
}