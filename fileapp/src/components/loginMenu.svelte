<script lang="ts">
	import { goto } from '$app/navigation';
	import { API_BASE_URL } from '$lib/config';
	import { User } from '$lib/models';
	import { Login } from '../stores/auth';

	let email: string = $state('');
	let password: string = $state('');

	let message: string = $state('');

	async function tryLogin(event: SubmitEvent) {
		event.preventDefault();

		const response: Response = await fetch(`${API_BASE_URL}/login`, {
			method: 'POST',
			headers: {
				'Content-type': 'application/json'
			},
			body: JSON.stringify({
				email: email,
				password: password
			})
		});

		if (!response.ok) {
			let json = await response.json();
			console.log(json);
			message = 'Could not log you in: ' + json.detail;
			return;
		}

		Login(response, new User(email));
		email = '';
		password = '';
		message = '';

		goto('/');
	}
</script>

<div class="login-window">
	<h2>Login</h2>
	<p style="margin-bottom: 1rem; color: red;">{message}</p>
	<form class="login-form" onsubmit={tryLogin}>
		<label for="email">Email:</label>
		<input
			type="email"
			name="email"
			id="email"
			placeholder="enter email..."
			bind:value={email}
			autocomplete="email"
		/>
		<label for="password" style="margin-top: 1rem;">Password:</label>
		<input
			type="password"
			name="password"
			id="password"
			style="margin-bottom: 1rem;"
			placeholder="enter password..."
			bind:value={password}
			autocomplete="current-password"
		/>
		<button type="submit">Login</button>
	</form>

	<p>Don't have an account yet?</p>
	<p>Register <a href="/register">here</a></p>
</div>

<style>
	.login-window {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		margin-top: var(--top-margin);
		width: var(--width);
		height: var(--height);
		background-color: var(--background-color, #ebebebff);
		border: 2px solid var(--border-color, #d6d6d6ff);
		border-radius: 10px;
	}

	.login-form {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	p {
		margin: 0;
	}

	button {
		--color: #0e79b2ff;
		font-family: inherit;
		width: 6em;
		height: 2.6em;
		line-height: 2.5em;
		overflow: hidden;
		cursor: pointer;
		margin: 20px;
		font-size: 17px;
		z-index: 1;
		color: var(--color);
		border: 2px solid var(--color);
		border-radius: 6px;
		position: relative;
	}

	button::before {
		position: absolute;
		content: '';
		background: var(--color);
		width: 150px;
		height: 200px;
		z-index: -1;
		border-radius: 50%;
	}

	button:hover {
		color: white;
	}

	button:before {
		top: 100%;
		left: 100%;
		transition: 0.3s all;
	}

	button:hover::before {
		top: -30px;
		left: -30px;
	}

	input {
		font-size: 16px;
		padding: 10px 10px 10px 5px;
		display: block;
		width: 200px;
		border: none;
		border-bottom: 1px solid #515151;
		background: transparent;
	}

	input:focus {
		outline: none;
	}
</style>
