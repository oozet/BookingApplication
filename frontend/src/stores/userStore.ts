// Not sure if this should be in store or in api/user
// export const userStore = writable(null); // Stores user session info
import { writable } from 'svelte/store';

export type User = {
    id: string;
    username: string;
    token?: string;
};

export type Booking = {
    id: string;
    userId: string;
    roomId?: string;
    activityId?: string;
    startTime: string;
    endTime: string;
    status: string;
    room?: {
        id: string;
        name: string;
        capacity: number;
    };
    activity?: {
        id: string;
        name: string;
        description: string;
    };
};

export const userStore = writable<User | null>(null);
export const userBookingsStore = writable<Booking[]>([]);

export async function login(username: string, password: string) {
    const response = await fetch('http://localhost:5133/user/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    });

    if (response.ok) {
        const data = await response.json();
        console.log('Login response:', data);
        
        // Store the user data and token
        userStore.set({
            id: data.id,
            username: data.username,
            token: data.token
        });
        
        // Store token in localStorage for persistence
        if (data.token) {
            localStorage.setItem('authToken', data.token);
        }
    } else {
        const errorData = await response.json();
        throw new Error(errorData.errors || 'Login failed');
    }
}

export async function register(username: string, email: string, password: string) {
    const response = await fetch('http://localhost:5133/user/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, email, password })
    });

    if (!response.ok) {
        const errorData = await response.text();
        throw new Error(errorData || 'Registration failed');
    }
}

export async function fetchUserBookings() {
    const token = localStorage.getItem('authToken');
    
    if (!token) {
        throw new Error('No authentication token found');
    }

    const response = await fetch('http://localhost:5133/user/bookings', {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
        const bookings = await response.json();
        userBookingsStore.set(bookings);
        return bookings;
    } else {
        const errorData = await response.json();
        throw new Error(errorData.errors || 'Failed to fetch bookings');
    }
}

export async function logout() {
    userStore.set(null);
    userBookingsStore.set([]);
    localStorage.removeItem('authToken');
}