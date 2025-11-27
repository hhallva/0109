ALTER TABLE CP_Categories
ADD CONSTRAINT FK_Category_Parent
FOREIGN KEY (parent_category_id) REFERENCES CP_Categories(category_id)
ON DELETE SET NULL;