<script lang="ts">
	import { error } from '@sveltejs/kit';
	import { userStore, login } from '../../api/user';
	import { onMount } from 'svelte';
	import Roompanel from '../../components/adminpanels/roompanel.svelte';
	import Userpanel from '../../components/adminpanels/userpanel.svelte';
	import Activitypanel from '../../components/adminpanels/activitypanel.svelte';
	import type { PageData } from './$types';

	let username = $state('');
	let password = $state('');
	let message = $state('');

	let authorized = $state(false);

	let acitivtyDropdownVisible = $state(false);
	let roomDropdownVisible = $state(false);
	let userDropdownVisible = $state(false);

	let { data }: { data: PageData } = $props();

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
	<button
		class="activity-button"
		onclick={() => {
			acitivtyDropdownVisible = !acitivtyDropdownVisible;
		}}>Acitiviy panel</button
	>
	<div class="act-drop">
		{#if acitivtyDropdownVisible}
			<Activitypanel activities={data.activities} />
		{/if}
	</div>
	<button
		class="room-button"
		onclick={() => {
			roomDropdownVisible = !roomDropdownVisible;
		}}>Room panel</button
	>
	<div class="room-drop">
		{#if roomDropdownVisible}
			<Roompanel rooms={data.rooms} />
		{/if}
	</div>
	<button
		class="user-button"
		onclick={() => {
			userDropdownVisible = !userDropdownVisible;
		}}>User panel</button
	>
	<div class="user-drop">
		{#if userDropdownVisible}
			<Userpanel users={[]} />
		{/if}
	</div>
{/if}

<style>
	button {
		width: 10rem;
		height: 2.8rem;
		line-height: 2.5rem;
		font-family: inherit;
		margin: 0.5rem;
	}
</style>
