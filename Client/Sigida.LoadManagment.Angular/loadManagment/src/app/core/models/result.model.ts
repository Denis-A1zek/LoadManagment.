export interface IResult<T>{
  payload: T;
  reason: string;
  isSuccess: boolean;
}