export interface ICategories {
  href: string;
  items: IItem2[];
  limit: number;
  next: string;
  offset: number;
  previous: any;
  total: number;
}

export interface IIcon {
  height: number;
  url: string;
  width: number;
}

export interface IItem2 {
  href: string;
  icons: IIcon[];
  id: string;
  name: string;
}

export interface ISeveralBrowse {
  categories: ICategories;
}