import jwt_decode from "jwt-decode";
import _ from "lodash";
import { IUser } from "../models/user/user";
export class DecodeJwt {
	static decodeJwt = (token:string): IUser | undefined => {
		try {
			if(token === null || token === undefined)
				return undefined;
			const user = jwt_decode<any>(token);
			return {
				name: user.Name,
				id: user.Id,
				createdOn: user.CreatedOn,
				updateOn: user.UpdateOn,
				state: user.State
			};
		} catch (error) {
			console.log("error decode token ==>", error);
		}
	};
}