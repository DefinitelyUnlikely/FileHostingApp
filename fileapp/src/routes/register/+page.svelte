<script lang="ts">
	import { API_BASE_URL } from '$lib/config';

	let email: string = $state('');
	let password: string = $state('');
	let repeatPassword: string = $state('');

	let message: string = $state('');
	let emailRegex: RegExp = /^\S+@\S+\.\S+$/;

	async function TryCreateUser() {
		if (email === '' || password === '' || repeatPassword === '') {
			message = 'Please enter all required information!';
			return;
		}

		if (!emailRegex.test(email)) {
			message = 'email is not on the correct format!';
			return;
		}

		if (password != repeatPassword) {
			message = 'Passwords did not match!';
			return;
		}

		message = '';

		let response = await fetch(`${API_BASE_URL}/register`, {
			method: 'POST',
			body: JSON.stringify({
				email: email,
				password: password
			}),
			headers: {
				'Content-type': 'application/json'
			}
		});

		if (!response.ok) {
			message = `Your account could not be created: ${response.status}`;
			return;
		}

		email = '';
		password = '';
		repeatPassword = '';
		message = 'You have been registered. Please log in!';
	}
</script>

<h2>Register New User</h2>

<form class="register-form" onsubmit={TryCreateUser}>
	<label for="username">User email:</label>
	<input
		class={['custom-input']}
		type="text"
		name="email"
		id="email"
		bind:value={email}
		autocomplete="email"
	/>

	<label for="password">Password:</label>
	<input
		type="password"
		name="password"
		id="password"
		bind:value={password}
		autocomplete="new-password"
	/>

	<label for="repeat-password">Repeat Password:</label>
	<input
		type="password"
		name="repeat-password"
		id="repeat-password"
		bind:value={repeatPassword}
		autocomplete="new-password"
	/>

	<button class="custom-button">Create new user</button>
</form>

<p>{message}</p>

<style>
	.register-form {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}
</style>
