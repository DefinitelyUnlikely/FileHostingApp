<script lang="ts">
	let callUrl: string = 'http://localhost:5282/register';

	let email: string = $state('');
	let password: string = $state('');
	let repeatPassword: string = $state('');

	let error: string = $state('');

	async function CreateUser() {
		if (email === '' || password === '' || repeatPassword === '') {
			error = 'Please enter all required information!';
		}

		if (password != repeatPassword) {
			console.log('Passwords did not match!');
			error = 'Passwords did not match!';
		}

		// let body = {
		// 	email: email,
		// 	password: password
		// };

		// const response = await fetch(callUrl, {
		// 	method: 'POST',
		// 	headers: { 'Content-Type': 'application/json' },
		// 	body: JSON.stringify(body)
		// });

		// console.log(response);
	}
</script>

<h2>Register New User</h2>

<label for="username">User email:</label>
<input class={['custom-input']} type="text" name="email" id="email" bind:value={email} />

<label for="password">Password:</label>
<input type="password" name="password" id="password" bind:value={password} />

<label for="repeat-password">Repeat Password:</label>
<input type="password" name="repeat-password" id="repeat-password" bind:value={repeatPassword} />

<button class="custom-button" onclick={CreateUser}>Create new user</button>

{#if error === ''}
	<p></p>
{:else}
	<p>{error}</p>
{/if}

<style>
</style>
