import { get, writable } from 'svelte/store';
import { getCookie, setCookie, deleteCookie } from '../utils/cookies';
import { User } from '$lib/models';

const emptyUser: User = new User('')

export const isLoggedIn = writable(false);
export const user = writable(emptyUser);

export async function Login(tokenResponse: Response, userObj: User) {
    let json = await tokenResponse.json();
    setCookie("token", json.accessToken);
    setCookie("refresh", json.refreshToken)
    setCookie("userinfo", userObj.email)
    user.set(userObj);
    isLoggedIn.set(true);

}

export async function Logout() {
    deleteCookie("token");
    deleteCookie("refresh")
    deleteCookie("userinfo")
    user.set(emptyUser);
    isLoggedIn.set(false);
}
