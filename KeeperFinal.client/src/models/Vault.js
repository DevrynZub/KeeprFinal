

export class Vault {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.isPrivate = data.isPrivate
    this.creator = data.creator
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.creatorId = data.creatorId
  }
}



// let data =
// {
//   "id": 1,
//   "createdAt": "2023-08-28T16:06:43",
//   "updatedAt": "2023-08-28T16:06:43",
//   "name": "Kinda Regular",
//   "description": "Cool Cool Cool",
//   "img": "https://images.unsplash.com/photo-1600489000022-c2086d79f9d4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&h=400&q=60",
//   "isPrivate": false,
//   "creatorId": "64e8e541ad74581073a28ba9",
//   "creator": {
//     "id": "64e8e541ad74581073a28ba9",
//     "name": "goodkitty@goodtoken.com",
//     "picture": "https://s.gravatar.com/avatar/718cc5e475dbe783fa65361498fd64b2?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fgo.png"
//   },
//   "accountId": null
// }