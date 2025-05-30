export interface Activity {
    id: string;
    name: string;
    description?: string;
}

export type Booking = {
    day: number; // 0 = Sunday, 1 = Monday, ..., 6 = Saturday
    hour: number; // 0 = 00:00, 1 = 01:00, ..., 23 = 23:00
    info: string;
};