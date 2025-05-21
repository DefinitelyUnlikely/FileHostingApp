<script lang="ts">
	let email: string = $state('');
	let password: string = $state('');
	let repeatPassword: string = $state('');

	let error: string = $state('');
	let emailRegex: RegExp = /^\S+@\S+\.\S+$/;

	async function CreateUser() {
		if (email === '' || password === '' || repeatPassword === '') {
			error = 'Please enter all required information!';
			return;
		}

		if (!emailRegex.test(email)) {
			error = 'email is not on the correct format!';
			return;
		}

		if (password != repeatPassword) {
			error = 'Passwords did not match!';
			return;
		}

		error = '';
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

<p>{error}</p>

<style>
</style>
