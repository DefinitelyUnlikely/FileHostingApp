<script lang="ts">
	let callUrl: string = 'http://localhost:5282/register';

	let email: string = $state('');
	let password: string = $state('');

	async function CreateUser() {
		let body = {
			email: email,
			password: password
		};

		const response = await fetch(callUrl, {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(body)
		});

		console.log(response);
	}
</script>

<h2>Register user</h2>
<label for="username">User email:</label>
<input type="text" name="email" id="email" bind:value={email} />
<label for="password">Password:</label>
<input type="password" name="password" id="password" bind:value={password} />

<button onclick={CreateUser}>Create new user</button>
