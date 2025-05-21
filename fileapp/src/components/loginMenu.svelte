<div class="login-window">
	<label for="email-input">Email:</label>
	<input type="email" name="email" id="email" />
	<label for="password" style="margin-top: 1rem;">Password:</label>
	<input type="password" name="password" id="password" />
</div>

<style>
	.login-window {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		margin-top: 20%;
		width: var(--width);
		height: var(--height);
		background-color: #ebebebff;
		border: 2px solid #d6d6d6ff;
		border-radius: 10px;
	}
</style>
