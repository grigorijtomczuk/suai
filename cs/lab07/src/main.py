# 20. Разработать систему, реализующую CRUD операции с базой данных книжного магазина.

import json
import readline  # * readline позволяет использовать стрелки для навигации во время input()

from controllers import collections
from db import json_service


def require_collection_name():
  db = json_service.get_database()
  available_collections = [name for name in db if isinstance(db[name], list)]
  return input(f"Введите название коллекции ({", ".join(available_collections)}): ")


def require_id():
  try:
    return int(input("Введите ID: "))
  except:
    print("Введите ID, целое число!")


def write_dict():
  _dict = {}

  while True:
    field = input("Введите название поля (-1: закончить ввод): ")
    if field == "-1": break

    value_type = input("Введите тип данных значения поля (str, int, list, dict): ")

    match value_type:
      case "str":
        value = input("Введите значение: ")
      case "int":
        value = int(input("Введите значение: "))
      case "list":
        value = write_list()
      case "dict":
        value = write_dict()
      case _:
        value = None

    _dict[field] = value

  return _dict


def write_list():
  _list = []

  while True:
    value_type = input("Введите тип данных значения элемента (-1: закончить ввод) (str, int, list, dict): ")
    if value_type == "-1": break

    match value_type:
      case "str":
        value = input("Введите значение: ")
      case "int":
        value = int(input("Введите значение: "))
      case "list":
        value = write_list()
      case "dict":
        value = write_dict()
      case _:
        value = None

    _list.append(value)

  return _list


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
      id = require_id()
      print(format_json(collections.get_one_by_id(collection, id)))

    case "5":
      collection = require_collection_name()
      new_item = write_dict()
      print(format_json(collections.create_one(collection, new_item)))

    case "6":
      collection = require_collection_name()
      id = require_id()
      new_item = write_dict()
      print(format_json(collections.update_one_by_id(collection, id, new_item)))

    case "7":
      collection = require_collection_name()
      id = require_id()
      print(format_json(collections.delete_one_by_id(collection, id)))

    case _:
      print("Несуществующая операция!")