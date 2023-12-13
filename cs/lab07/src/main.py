# 20. Разработать систему, реализующую CRUD операции с базой данных книжного магазина.

import json

from controllers import collections
from db import json_service


def require_collection_name():
  db = json_service.get_database()
  available_collections = [name for name in db if isinstance(db[name], list)]
  return input(f"Введите название коллекции ({", ".join(available_collections)}): ")


format_json = lambda obj: json.dumps(obj, indent=2, ensure_ascii=False)

while True:
  operation = input("Выберите операцию (0: помощь): ")

  match operation:
    case "0":
      print("Доступные операции:\n"\
        "0: help\n"\
        "1: get_name\n"\
        "2: get_address\n"\
        "3: get_all\n"\
        "4: get_one_by_id\n"\
        "5: create_one\n"\
        "6: update_one_by_id\n"\
        "7: delete_one_by_id")

    case "1":
      print(format_json(collections.get_name()))

    case "2":
      print(format_json(collections.get_address()))

    case "3":
      collection = require_collection_name()
      print(format_json(collections.get_all(collection)))

    case "4":
      collection = require_collection_name()
      id = int(input("Введите ID: "))
      print(format_json(collections.get_one_by_id(collection, id)))

    case "5":
      collection = require_collection_name()
      collections.create_one(collection, {
        "name": "Тест Тест",
        "courses_id": [1, 2],
        "contacts": {
          "email": "тест@example.com",
          "phone": "+333333",
        },
      })

    case "6":
      collection = require_collection_name()
      id = int(input("Введите ID: "))
      print(format_json(collections.update_one_by_id(collection, id, {
        "name": "Не Смирнова Екатерина",
        "contacts": {
          "email": "нет@example.com",
          "phone": "+1122334455",
        },
      })))

    case "7":
      collection = require_collection_name()
      id = int(input("Введите ID: "))
      print(format_json(collections.delete_one_by_id(collection, id)))

    case _:
      print("Несуществующая операция!")
