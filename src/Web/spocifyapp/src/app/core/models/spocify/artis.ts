export interface Artist {
    external_urls: {
      spotify: string
    },
    followers: {
      href: string,
      total: number
    },
    genres: [],
    href: string,
    id: string,
    images: [],
    name: string,
    popularity: number,
    type: Artist,
    uri: string
  }