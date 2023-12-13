from db import json_service

db = json_service.get_database()


def get_name():
  return db["name"]


def get_address():
  return db["address"]


def get_one_by_id(collection, id):
  for item in db[collection]:
    if item["id"] == id:
      return item

  return {"message": f"Элемент {id=} не найден в {collection}!"}


def get_all(collection):
  return db[collection]


def create_one(collection, new_item):
  last_item_id = get_all(collection)[-1]["id"] if get_all(collection) else 0
  item = {"id": last_item_id + 1, **new_item}
  db[collection].append(item)
  json_service.set_database(db)
  return item


def update_one_by_id(collection, id, new_item):
  for item in db[collection]:
    if item["id"] == id:
      for attr in item:
        item[attr] = new_item[attr] if new_item[attr] else item[attr]
      json_service.set_database(db)
      return item

  return {"message": f"Элемент {id=} не найден в {collection}!"}


def delete_one_by_id(collection, id):
  for i, item in enumerate(db[collection]):
    if item["id"] == id:
      deleted_item = db[collection].pop(i)
      json_service.set_database(db)
      return deleted_item

  return {"message": f"Элемент {id=} не найден в {collection}!"}
