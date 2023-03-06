# GraphQL

Example of queries:
query{
  authors(take: 4, where: { name: { contains: "a"}}) {
    items: items {id, name, bornDate}
  }
}

--------
query{
  authors(take: 2, skip: 2) {
    items: items {name}
  }
}
