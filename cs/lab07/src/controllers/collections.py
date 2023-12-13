from db import collections


def get_name():
  try:
    return collections.get_name()
  except:
    raise


def get_address():
  try:
    return collections.get_address()
  except:
    raise


def get_one_by_id(collection, id):
  try:
    return collections.get_one_by_id(collection, id)
  except:
    raise


def get_all(collection):
  try:
    return collections.get_all(collection)
  except:
    raise


def create_one(collection, new_item):
  try:
    return collections.create_one(collection, new_item)
  except:
    raise


def update_one_by_id(collection, id, new_item):
  try:
    return collections.update_one_by_id(collection, id, new_item)
  except:
    raise


def delete_one_by_id(collection, id):
  try:
    return collections.delete_one_by_id(collection, id)
  except:
    raise
