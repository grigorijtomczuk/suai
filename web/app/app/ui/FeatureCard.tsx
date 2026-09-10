// Readonly не позволяет компоненту изменять полученные свойства.
type FeatureCardProps = Readonly<{
  title: string;
  description: string;
}>;

export default function FeatureCard({
  title,
  description,
}: FeatureCardProps) {
  return (
    // Article сохраняет смысл карточки как самостоятельного материала.
    <article className="feature-card">
      <span className="feature-card__marker" aria-hidden="true" />
      <h3>{title}</h3>
      <p>{description}</p>
    </article>
  );
}
