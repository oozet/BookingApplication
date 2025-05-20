<script lang="ts">
    import { onMount } from 'svelte';
    import { register, authStore } from '../../stores/authStore'; // A store to track login state

    
    let user: any;
    $: authStore.subscribe(value => user = value);

    let username = '';
    let email = '';
    let password = '';
    let errorMessage = '';

    async function handleRegister() {
        errorMessage = '';

        try {
            register(username, email, password);
        } catch (error: any) {
            errorMessage = error.message;
        }
    }
</script>

{#if !user}
<form on:submit|preventDefault={handleRegister}>
    <label>
        Username:
        <input type="text" bind:value={username} required />
    </label>

    <label>
        Email:
        <input type="email" bind:value={email} required />
    </label>

    <label>
        Password:
        <input type="password" bind:value={password} required />
    </label>

    {#if errorMessage}
        <p class="error">{errorMessage}</p>
    {/if}

    <button type="submit">Register</button>
</form>

{:else}
    <p>Welcome, {user.username}!</p>
{/if}

<style>
    .error { color: red; }
</style>