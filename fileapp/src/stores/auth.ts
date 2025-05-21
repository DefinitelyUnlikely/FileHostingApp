import { writable } from 'svelte/store';
import { getCookie, setCookie } from '../utils/cookies';
import { User } from '$lib/user';

const emptyUser: User = new User('')

export const isLoggedIn = writable(false);
export const user = writable(emptyUser);

export async function login(tokenResponse: Response, userObj: User) {
    let json = await tokenResponse.json();
    setCookie("cred", json);
    user.set(userObj);
    isLoggedIn.set(true);
}

export async function logout() {
    setCookie("cred", '')
    user.set(emptyUser);
    isLoggedIn.set(false);
}