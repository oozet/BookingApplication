import { writable } from 'svelte/store';

export const authStore = writable(null); // Stores user session info

export async function login(username: string, password: string) {
    const response = await fetch('http://localhost:5133/user/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    });

    if (response.ok) {
        const data = await response.json();
        console.log(data);
        authStore.set(data); // Store user session
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