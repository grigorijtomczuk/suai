from db import collections


def get_name():
  try:
    return collections.get_name()
  except:
    return {"message": "Что-то пошло не так!"}


def get_address():
  try:
    return collections.get_address()
  except:
    return {"message": "Что-то пошло не так!"}


def get_one_by_id(collection, id):
  try:
    return collections.get_one_by_id(collection, id)
  except:
    return {"message": "Что-то пошло не так!"}


def get_all(collection):
  try:
    return collections.get_all(collection)
  except:
    return {"message": "Что-то пошло не так!"}


def create_one(collection, new_item):
  try:
    return collections.create_one(collection, new_item)
  except:
    return {"message": "Что-то пошло не так!"}


def update_one_by_id(collection, id, new_item):
  try:
    return collections.update_one_by_id(collection, id, new_item)
  except:
    return {"message": "Что-то пошло не так!"}


def delete_one_by_id(collection, id):
  try:
    return collections.delete_one_by_id(collection, id)
  except:
    return {"message": "Что-то пошло не так!"}
