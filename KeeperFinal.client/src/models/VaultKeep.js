import { Account } from "./Account.js";


export class VaultKeep extends Account {
  constructor(data) {
    super(data)
    this.vaultKeepId = data.vaultKeepId
  }
}