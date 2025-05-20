<script lang="ts">
import CreateBooking from '../../components/createbooking.svelte';
import { authStore } from '../../stores/authStore';
    let user: any;
    $: authStore.subscribe(value => user = value);
</script>

{#if !user}
    <p>You must be logged in to view this page.</p>
    <p><a href="/register">Register</a> | <a href="/login">Login</a></p>
{:else}
    <p>Welcome, {user.username}!
    </p>
{/if}

<CreateBooking />
