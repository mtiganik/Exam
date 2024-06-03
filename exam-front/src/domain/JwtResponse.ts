export interface JwtResponse{
  "jwt": string;
  "refreshToken": string;
  "userName": string;
  "email": string;
  "firstName": string;
  "lastName": string;
  "role": string[];

}