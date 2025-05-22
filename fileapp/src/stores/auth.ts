import { get, writable } from 'svelte/store';
import { getCookie, setCookie, deleteCookie } from '../utils/cookies';
import { User } from '$lib/models';

export const isLoggedIn = writable(false);
export const useremail = writable('');

export async function Login(tokenResponse: Response, userObj: User) {
    let json = await tokenResponse.json();
    setCookie("token", json.accessToken);
    setCookie("refresh", json.refreshToken)
    setCookie("userinfo", userObj.email)
    useremail.set(userObj.email);
    isLoggedIn.set(true);

}

export async function Logout() {
    deleteCookie("token");
    deleteCookie("refresh")
    deleteCookie("userinfo")
    useremail.set('');
    isLoggedIn.set(false);
}

