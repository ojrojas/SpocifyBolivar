export interface Categories {
  href: string;
  items: Item2[];
  limit: number;
  next: string;
  offset: number;
  previous: any;
  total: number;
}

export interface Icon {
  height: number;
  url: string;
  width: number;
}

export interface Item2 {
  href: string;
  icons: Icon[];
  id: string;
  name: string;
}

export interface SeveralBrowse {
  categories: Categories;
}