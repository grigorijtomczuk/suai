from utils import json_service


def get_one_by_id(id):
  db = json_service.get_database()

  for item in db["teachers"]:
    if item["id"] == id:
      return item

  return {"message": f"Элемент с {id} не найден"}


def get_all():
  db = json_service.get_database()
  return db["teachers"]


def create_one(teacher):
  db = json_service.get_database()
  last_teacher_id = get_all()[-1]["id"] if get_all() else 0
  db["teachers"].append({"id": last_teacher_id + 1, **teacher})
  json_service.set_database(db)


def update_one_by_id(id, teacher):
  db = json_service.get_database()

  for item in db["teachers"]:
    if item["id"] == id:
      item["name"] = teacher["name"]
      item["contacts"] = teacher["contacts"]
      json_service.set_database(db)
      return item

  return {"message": f"Элемент с {id} не найден"}


def delete_one_by_id(id):
  db = json_service.get_database()

  for i, item in enumerate(db["teachers"]):
    if item["id"] == id:
      candidate = db["teachers"].pop(i)
      json_service.set_database(db)
      return candidate

  return {"message": f"Элемент с {id} не найден"}
