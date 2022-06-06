
export interface Response<T> {
  success?: boolean;
  total_elements: number;
  article?: T;
  articles?: T;
  store?: T;
  stores?: T;
}
