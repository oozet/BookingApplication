import { writable } from 'svelte/store';

export type User = {
    id: number;
    username: string;
};
export const userStore = writable<User | null>(null); // Stores user session info

export async function login(username: string, password: string) {
    const response = await fetch('http://localhost:5133/user/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    });

    if (response.ok) {
        const data = await response.json();
        if (data?.id && data?.username) {
            userStore.set({ id: data.id, username: data.username });
        } else {
            console.error("Invalid API response:", data);
        }
        console.log(data);
        userStore.set(data); // Store user session
    }
}

export async function register(username: string, email: string, password: string) {
    const response = await fetch('http://localhost:5133/user/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, email, password })
    });

    if (!response.ok) {
        const data = await response.text();
        console.log(data);
        return;
    }

    if (response.ok) {
        const data = await response.text();
        console.log(data);
        return;
    }
}