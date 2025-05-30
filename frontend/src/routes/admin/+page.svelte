<script lang="ts">
	import { error } from '@sveltejs/kit';
	import { userStore, login } from '../../api/user';
	import { onMount } from 'svelte';

	let username = $state('');
	let password = $state('');
	let message = $state('');

	let authorized = $state(false);

	onMount(async () => {
		const isAdmin = await fetch('http://localhost:5133/user/is-admin', {
			method: 'GET',
			credentials: 'include', // This includes cookies
			headers: {
				'Content-Type': 'application/json'
			}
		});

		if (isAdmin.ok) {
			authorized = true;
			return;
		}
	});

	async function tryLogin() {
		login(username, password);

		const isAdmin = await fetch('http://localhost:5133/user/is-admin', {
			method: 'GET',
			credentials: 'include', // This includes cookies
			headers: {
				'Content-Type': 'application/json'
			}
		});

		if (isAdmin.ok) {
			authorized = true;
			return;
		}

		error(401, 'Not an admin');
	}
</script>

{#if !authorized}
	<p>To access Admin functionallity, you need to enter your credentials again:</p>

	<form onsubmit={tryLogin}>
		<label>
			Username:
			<input type="text" bind:value={username} required autocomplete="username" />
		</label>

		<label>
			Password:
			<input type="password" bind:value={password} required autocomplete="current-password" />
		</label>

		{#if message}
			<p class="error">{message}</p>
		{/if}

		<button type="submit">Login</button>
	</form>
{:else}
	logged in
{/if}

<style></style>
