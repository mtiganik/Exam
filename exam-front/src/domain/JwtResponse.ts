export interface JwtResponse{
  "jwt": string;
  "refreshToken": string;
  "userName": string;
  "email": string;
  "role": string[];
  "companyId": string;
}